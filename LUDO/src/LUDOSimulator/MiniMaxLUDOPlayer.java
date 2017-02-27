package LUDOSimulator;
import java.util.Random;
/**
 * Example of automatic LUDO player
 * @author Adam Czerwinski
 * 
 * @version 0.9
 *
 */
public class MiniMaxLUDOPlayer implements LUDOPlayer {

	LUDOBoard board;
	Random rand;
	public MiniMaxLUDOPlayer(LUDOBoard board)
	{
		this.board = board;
		rand = new Random();
	}

	public void play() {
		board.print("Minimaxed Player playing");

		int[] myBricksValue = new int[4];  
		board.rollDice();
		float max =-99999999;
		int bestIndex = -1;

		for(int i=0;i<4;i++)
		{
			float value = analyzeBrickSituation(i); 
			if(value>max) {
				bestIndex = i;
				max = value;
			}
		}
		if(bestIndex!=-1) board.moveBrick(bestIndex);
/*		
		System.out.println("Yellow: " + Score(board.getBoardState(),0));
		System.out.println("Red: " + Score(board.getBoardState(),1));
		System.out.println("Blue: " + Score(board.getBoardState(),2));
		System.out.println("Green: " + Score(board.getBoardState(),3));
	*/
	}

	
	
	
	public float[] Score(int boardState[][], int playerscorewanted){


		float[] scores = new float[4];
float[] finalScores = new float[4];

//i = playernumber
//j = pawnnumber;



		for(int i = 0; i<4;i++){
			scores[i] = 0;	
			for(int j = 0; j<4;j++){
				scores[i] += CountFieldsToHome(boardState, i, j);
			}
			
			
		}
		
			finalScores[0] = scores[0] - scores[1] - scores[2] - scores[3];
			finalScores[1] = scores[1] - scores[0] - scores[2] - scores[3];
			finalScores[2] = scores[2] - scores[0] - scores[1] - scores[3];
			finalScores[3] = scores[3] - scores[0] - scores[1] - scores[2];
		return finalScores;
	}
	
	
	
	
	public float CountFieldsToHome(int[][] boardState, int playernumber, int pawnnr){
		float points = 0;
		if (board.isDone(playernumber)) {
			return 1000;
		}
		if (board.almostHome(boardState[playernumber][pawnnr],playernumber)) {
			return 60;
		}
		if (board.atHome(boardState[playernumber][pawnnr], playernumber)) {
			return 100;
		}
		if(board.isGlobe(boardState[playernumber][pawnnr])){
			points -= 3;
		}
		
/*		if (board.inStartArea(boardState[playernumber][pawnnr], playernumber)) {
			return 0;
		}
*/
		int start ;
		int slut;


		switch (playernumber) {
		case 0:

			start = 0;
			slut = 50;

			break;

		case 1:
			start = 13;
			slut = 11;


			break;
		case 2:
			start = 26;
			slut = 24;
			break;
		case 3:
			start = 39;
			slut = 37;
			break;
		default:

			start = 0;
			slut = 50;
			break;
		}
		if (boardState[playernumber][pawnnr]>= 0 && boardState[playernumber][pawnnr]<=51) 
		{

			if (playernumber == 1) {
				//System.out.println("Now its player 0");
			}
			int x = boardState[playernumber][pawnnr];

			start = x;
			if (start<slut) {
				points = slut-start;
			}
			else{
				points = 52- Math.abs(slut-start);

			}
			return 52 - points;
		}

		else{

			return 0;

		}

	}


/*
public float MiniMax(int[][] boardstate){
	
	int bestMove =-1;
	float bestScore = -99999999;
	for (int i = 0; i < 4; i++) {
		board.getNewBoardState(nr, color, dice2)
	}
	
	return 2;
}
*/





	
// laver scoren for en enkelt brik.
	public float MiniMax(int pawnnr){
		float result = 0;
		int [][] boardstatex = board.getNewBoardState(pawnnr, board.getMyColor(), board.getDice());

		result +=  Score(boardstatex, board.getMyColor())[0] +rand.nextFloat(); 

		for (int play = 1; play < 4; play++) {
			for (int pawn = 0; pawn < 4; pawn++) {
				for (int die = 1; die < 7; die++) {
					result+= Score(board.getNewBoardState(boardstatex , pawn, play, die),board.getMyColor())[0];
				}
			}
		}
	
		return result;
}

/*
	public float Max(int[][] bs,int depth, int maxdepth, int currentplayer){
		if (depth== maxdepth) 
		{
			return Score(bs, currentplayer)[currentplayer];
		}	
		else {
			float bestScore = -99999999;
			
		}
		
		return 2;
	}
	
	public float Mini(){
		
		return 4;
		
	}
	*/
		
	
	


//I er brikken vi kigger på.
	public float analyzeBrickSituation(int i) {
		if(board.moveable(i)) {
		
			
		
//return CountFieldsToHome(board.getNewBoardState(i, board.getMyColor(), board.getDice()), board.getMyColor(), i);	
return MiniMax(i);
			
		}
		else {
			return -999999999;
		}
		
	}
		
		
		
	


	private boolean moveOut(int[][] current_board, int[][] new_board) {
		for(int i=0;i<4;i++) {
			if(board.inStartArea(current_board[board.getMyColor()][i],board.getMyColor())&&!board.inStartArea(new_board[board.getMyColor()][i],board.getMyColor())) {
				return true;
			}
		}
		return false;
	}

	private boolean hitOpponentHome(int[][] current_board, int[][] new_board) {
		for(int i=0;i<4;i++) {
			for(int j=0;j<4;j++) {
				if(board.getMyColor()!=i) {
					if(board.atField(current_board[i][j])&&!board.atField(new_board[i][j])) {
						return true;
					}
				}
			}
		}
		return false;
	}
	private boolean hitMySelfHome(int[][] current_board, int[][] new_board) {
		for(int i=0;i<4;i++) {
			if(!board.inStartArea(current_board[board.getMyColor()][i],board.getMyColor())&&board.inStartArea(new_board[board.getMyColor()][i],board.getMyColor())) {
				return true;
			}
		}
		return false;
	}
}
