package LUDOSimulator;
import java.util.Random;
/**
 * Example of automatic LUDO player
 * @author Adam Czerwinski
 * 
 * @version 0.9
 *
 */
public class SemiSmartLUDOPlayer2 implements LUDOPlayer {

	LUDOBoard board;
	Random rand;
	public SemiSmartLUDOPlayer2(LUDOBoard board)
	{
		this.board = board;
		rand = new Random();
	}

	public void play() {
		board.print("Semi Smart player playing");

		int[] myBricksValue = new int[4];  
		board.rollDice();
		float max =-1;
		int bestIndex = -1;
		for(int i=0;i<4;i++)
		{
			float value = analyzeBrickSituation(i); 
			if(value>max&&value>0) {
				bestIndex = i;
				max = value;
			}
		}
		if(bestIndex!=-1) board.moveBrick(bestIndex);
	}
	public float analyzeBrickSituation(int i) {
		if(board.moveable(i)) {
			return CountFieldsToHome(board.getNewBoardState(i, board.getMyColor(), board.getDice()), board.getMyColor(), i);	

		}
		else {
			return 0;
		}
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
				points = 52- Math.abs(slut-start);

			}
			return 52 - points;
		}

		else{

			return 0;

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
