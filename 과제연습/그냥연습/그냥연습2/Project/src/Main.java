import javax.swing.JFrame;

public class Main extends JFrame {
	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("Test");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLocationRelativeTo(null);
		
		int h=400, v=100;
		int t=800, c=400;
		frame.setSize(h, v);
		frame.setVisible(true);
		
		while (true) {
			for (h=t; h>c; h--) frame.setSize(h, v);
			
			for (h=c; h<t; h++) frame.setSize(h, v);
			
			for (v=t; v>c; v--) frame.setSize(h, v);
			
			for (v=c; v<t; v++) frame.setSize(h, v);
		}
	}
}
