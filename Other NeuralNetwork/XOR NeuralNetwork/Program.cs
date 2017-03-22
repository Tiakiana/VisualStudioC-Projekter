using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    public  class Program
    {
        private static OutputNeuron OutPutNeuron1;
        private static Neuron HiddenNeuron1;
        private static Neuron HiddenNeuron2;
        private static Neuron HiddenNeuron3;
        static void Main(string[] args)
        {
            double[] d = new double[2];

            d[0] = 1.5;
            d[1] = 3;
       //     d[2] = 4;

            Console.WriteLine(sigmoid.Softmax(d)[0]);
            Console.WriteLine(sigmoid.Softmax(d)[1]);
         //   Console.WriteLine(sigmoid.Softmax(d)[2]);
            Console.WriteLine(sigmoid.Softmax(d)[0] + sigmoid.Softmax(d)[1]);// + sigmoid.Softmax(d)[2]);


            Console.WriteLine("How many times should I train?");
            int epo = int.Parse(Console.ReadLine());

            train(epo);
            Console.WriteLine("Write the first number (1 or 0)");
            double X = double.Parse(Console.ReadLine());
            Console.WriteLine("Write the Second number (1 or 0)");

            double Y = double.Parse(Console.ReadLine());

            HiddenNeuron1.inputs = new double[] { X, Y};
            HiddenNeuron2.inputs = new double[] { X,Y};

            OutPutNeuron1.inputs = new double[] { HiddenNeuron1.output, HiddenNeuron2.output };

            Console.WriteLine("Hmm let's see. Based on my training I'd give it exactly " + OutPutNeuron1.output * 100 + "% chance of being a True!");


            if (OutPutNeuron1.output>0.5)
            {
                Console.WriteLine("So my guess is that "+ X + " + " + Y +" Should be True");
            }
            else
            {
                Console.WriteLine("So my guess is that "+X + " + " + Y + " Should be False");

            }



            Console.WriteLine("lol");
            Console.ReadKey();
        }




        class sigmoid
        {
            public static double[] Softmax(double[] oSums)
            {
                // determine max output sum
                // does all output nodes at once so scale doesn't have to be re-computed each time
                double max = oSums[0];
                for (int i = 0; i < oSums.Length; ++i)
                    if (oSums[i] > max) max = oSums[i];

                // determine scaling factor -- sum of exp(each val - max)
                double scale = 0.0;
                for (int i = 0; i < oSums.Length; ++i)
                    scale += Math.Exp(oSums[i] - max);

                double[] result = new double[oSums.Length];
                for (int i = 0; i < oSums.Length; ++i)
                    result[i] = Math.Exp(oSums[i] - max) / scale;

                return result; // now scaled so that xi sum to 1.0
            }

            public static double output(double x)
            {
                return 1.0 / (1.0 + Math.Exp(-x));
            }

            public static double derivative(double x)
            {
                return x * (1 - x);
            }
        }

        class  Neuron
        {
            public double[] inputs = new double[2];
            public double[] weights = new double[2];
            public double error;

            private double biasWeight;

            private Random r = new Random();

            public double output
            {
                get { return sigmoid.output(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight); }
            }
            

            public void randomizeWeights()
            {
                weights[0] = r.NextDouble();
                weights[1] = r.NextDouble();
                biasWeight = r.NextDouble();
            }

            public void adjustWeights()
            {
                weights[0] += error * inputs[0];
                weights[1] += error * inputs[1];
                biasWeight += error;
            }
        }
        class OutputNeuron
        {
            public double[] inputs = new double[3];
            public double[] weights = new double[3];
            public double error;

            private double biasWeight;

            private Random r = new Random();

          /*  public double output
            {
                get { return sigmoid.output(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight); }
            }
            */
            public double[] output()
            {
                double[] d = new double[3];
                d[0] = biasWeight + inputs[0]*weights[0];
                d[1] = biasWeight + inputs[1]*weights[1];
                d[2] = biasWeight + inputs[2]*weights[2];
                return sigmoid.Softmax(d);
            }



            public void randomizeWeights()
            {
                weights[0] = r.NextDouble();
                weights[1] = r.NextDouble();
                weights[2] = r.NextDouble();
                biasWeight = r.NextDouble();
            }

            public void adjustWeights()
            {
                weights[0] += error * inputs[0];
                weights[1] += error * inputs[1];
                weights[2] += error * inputs[2];
                biasWeight += error;
            }
        }

        private static void train( int ep)
        {
            // the input values
            double[,] inputs =
            {
                { 0, 0},
                { 0, 1},
                { 1, 0},
                { 1, 1}
            };

            // desired results
            double[] results = { 0, 1, 1, 0 };

            // creating the neurons
            Neuron hiddenNeuron1 = new Neuron();
            Neuron hiddenNeuron2 = new Neuron();
            Neuron hiddenNeuron3 = new Neuron();
            OutputNeuron outputNeuron = new OutputNeuron();

            // random weights
            hiddenNeuron1.randomizeWeights();
            hiddenNeuron2.randomizeWeights();
            hiddenNeuron3.randomizeWeights();
            outputNeuron.randomizeWeights();

            int epoch = 0;

            Retry:
            epoch++;
            for (int i = 0; i < 4; i++)  // very important, do NOT train for only one example
            {
                // 1) forward propagation (calculates output)
                hiddenNeuron1.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
                hiddenNeuron2.inputs = new double[] { inputs[i, 0], inputs[i, 1] };

                outputNeuron.inputs = new double[] { hiddenNeuron1.output, hiddenNeuron2.output };

                Console.WriteLine("{0} xor {1} = {2}", inputs[i, 0], inputs[i, 1], outputNeuron.output());
                Console.WriteLine(outputNeuron.output()[0]);
                Console.WriteLine(outputNeuron.output()[1]);
                Console.WriteLine(outputNeuron.output()[2]);
                // 2) back propagation (adjusts weights)

                // adjusts the weight of the output neuron, based on its error
                outputNeuron.error = sigmoid.derivative(outputNeuron.output) * (results[i] - outputNeuron.output);

                //get { return sigmoid.output(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight); }

                outputNeuron.adjustWeights();

                // then adjusts the hidden neurons' weights, based on their errors
                hiddenNeuron1.error = sigmoid.derivative(hiddenNeuron1.output) * outputNeuron.error * outputNeuron.weights[0];
                hiddenNeuron2.error = sigmoid.derivative(hiddenNeuron2.output) * outputNeuron.error * outputNeuron.weights[1];

                hiddenNeuron1.adjustWeights();
                hiddenNeuron2.adjustWeights();
            }

            if (epoch < ep)
                goto Retry;
            OutPutNeuron1 = outputNeuron;
            HiddenNeuron1 = hiddenNeuron1;
            HiddenNeuron2 = hiddenNeuron2;
            Console.ReadLine();
        }
    }


}

