package LUDOSimulator;
import java.util.Random;
/**
 * Example of automatic LUDO player
 * @author Adam Czerwinski
 * 
 * @version 0.9
 *
 */
public class MiniMaxLUDOPlayer2 implements LUDOPlayer {

	LUDOBoard board;
	Random rand;
	public int depth = 3;
	public int [][] tempBoardState;
	public int maxDepth = 4;
	public int currentDepth =0;
	public int best;

	public MiniMaxLUDOPlayer2(LUDOBoard board)
	{
		this.board = board;
		rand = new Random();
	}
	int bestIndex = -1;
	public void play() {
		board.print("Minimaxed Player playing");

		int[] myBricksValue = new int[4];  
		board.rollDice();
		float max =-99999999;
		/*
		int[][] tempBoardState;
		for(int i=0;i<4;i++)
		{
			float value = analyzeBrickSituation(i); 
			if(value>max) {
				bestIndex = i;
				max = value;
			}
		
		
		if(bestIndex!=-1) board.moveBrick(bestIndex);

		
		//MiniMax2(0);
		
		*/
		MINIMAX(board.getBoardState(),2);
	
		}
		
		
	

	public float MiniMax2(int pawnnr){
		tempBoardState = board.getBoardState();
		currentDepth = 0;
		maxDepth = 1;
		float score = Min(pawnnr);
return score;		
		
}
	
	public float Max(int pawn){
		
		if (isGameOverComputer(tempBoardState)) {
			return 4000000;
		}
	else if (currentDepth== maxDepth) {
		//currentDepth = 0;
		return CountFieldsToHome(tempBoardState,0, pawn);
	}
	else{
		currentDepth++;
		float bestScore = -99999;
		for (int pawn1 = 0; pawn1 < 4; pawn1++) {
			for (int i = 1; i < 7; i++) {
				tempBoardState = board.getNewBoardState(tempBoardState, pawn1, board.getMyColor(), i);
				float score =Min(pawn);
				if (score> bestScore) {
					bestScore = score;
					bestIndex = pawn1;
				
				}
				tempBoardState = board.getNewBoardState(tempBoardState, pawn1, board.getMyColor(),-i);
				
				
			}
			
		}
		return bestScore;
	}
		
	}
	
	public float Min(int pawn){
		float bestScore = -99999;
		
		if (isGameOverComputer(tempBoardState)) {
		return -4000000;
	}
	else if (currentDepth== maxDepth) {
		//currentDepth = 0;
		return CountFieldsToHome(tempBoardState,0, pawn);
		
	}
	else{
		
		for (int pawn1 = 0; pawn1 < 4; pawn1++) {
			for (int i = 1; i < 7; i++) {
				tempBoardState = board.getNewBoardState(tempBoardState, pawn1, board.getMyColor(), i);
				float score = Max(pawn);
				if (score < bestScore) {
					bestScore = score;
					best = pawn1;
				
				}
				tempBoardState = board.getNewBoardState(tempBoardState, pawn1, board.getMyColor(),-i);
				
				
			}
			
		}
				}
		return bestScore;
		
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
	
	public boolean isGameOverComputer(int[][] BoardState){
		boolean res = true;
			for (int pawn = 0; pawn < 4; pawn++) {
				if (BoardState[0][pawn] != ((1) * 100 +9)){
					res = false;
				}
			}
			
		
		return res;
	}
	
	public boolean isGameOverHuman(int[][] BoardState){
		boolean res = true;
		for (int color = 0; color < 4; color++) {
			for (int pawn = 0; pawn < 4; pawn++) {
				if (BoardState[color][pawn] != ((color+1 *100+9))) {
					res = false;
				}
			}
			
		}
		return res;
		
		
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
			points -=4
					;
		}
		
		if (board.inStartArea(boardState[playernumber][pawnnr], playernumber)) {
			return -10;
		}

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
				points = Math.abs(slut-start);

			}
			return 52 - points;
		}

		else{

			return 0;

		}

	}
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

//I er brikken vi kigger på.
	public float analyzeBrickSituation(int i) {
		if(board.moveable(i)) {
		
			
		
//return CountFieldsToHome(board.getNewBoardState(i, board.getMyColor(), board.getDice()), board.getMyColor(), i);	
return MiniMax2(i);
			
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
	
	
	
	
	// Forsøg 2:
	
	float bestScoreMX;
	float bestScoreMN;
	
	float moveScore;
	
	int bestest = -1;
	
	public float MAX(int [][] boardState, int depth, int playerNumber){
		if (isGameOverComputer(boardState)) {
			return 4000000;
		}
		
		if (depth<= 0) {
			//return CountFieldsToHome(boardState, playerNumber, pawnnr);
	return  Score(boardState,playerNumber)[playerNumber];
		}
		else{
			
			bestScoreMX = -999999;
			for (int pawn = 0; pawn < 4; pawn++) {
				if (board.moveable(pawn)) {
					for (int dice = 1; dice < 7; dice++) {
						int [][] tempBoardState = board.getNewBoardState(boardState, pawn, playerNumber, dice);
						moveScore = MIN(tempBoardState,depth, 1) + MIN(tempBoardState,depth, 2) + MIN(tempBoardState,depth, 3);
						if (moveScore>bestScoreMX) {
							bestest = pawn;
							bestScoreMX = moveScore;
						}
						
					}
				} 
				
			}
		}
		
		return bestScoreMX;
	}
	
	public float MIN(int[][] boardState,int depth, int playerNumber){
		if (isGameOverHuman(boardState)) {
			return -4000000;
		}
		if (depth<= 0) {
			//	return CountFieldsToHome(boardState, playerNumber, pawnnr);
		return Score(boardState,playerNumber)[playerNumber];
			}
			else{
				
				bestScoreMN = 999999;
				for (int pawn = 0; pawn < 4; pawn++) {
					if (board.moveable(pawn)) {
						for (int dice = 1; dice < 7; dice++) {
							int [][] tempBoardState = board.getNewBoardState(boardState, pawn, playerNumber, dice);
							
							moveScore = MAX(tempBoardState,depth-1, 0);
							if (moveScore<bestScoreMN) {
								bestest = pawn;
								bestScoreMN = moveScore;
							}
							
						}
					} 
					
				}
			}
			
			return bestScoreMN;
	}
	
	public void MINIMAX(int[][]boardState, int depth){
		bestest =-1;
		bestScoreMN = -999999;
		bestScoreMX = 999999;
		int[][] tempBoardState;
		for (int pawn = 0; pawn < 4; pawn++) {
			
				tempBoardState = board.getNewBoardState(board.getBoardState(), pawn, board.getMyColor(), board.getDice());
				moveScore = MAX(tempBoardState,depth,1) +MIN(tempBoardState,depth,2) + MIN(tempBoardState,depth,3) ;
			
		 
		}
		if (bestest != -1) {
			board.moveBrick(bestest);
		}
		
	}
	
	
	
	
}
