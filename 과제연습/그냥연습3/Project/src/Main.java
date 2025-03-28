import java.awt.Color;
import java.awt.GridLayout;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Main {
	
	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("만능그림판");
		frame.setSize(400, 400);
		
		frame.setLayout(new GridLayout(100, 100));
		for (int i=1; i<=10000; i++) {
			JButton jb;
			frame.add(jb = new JButton());
			jb.addMouseListener(new MouseListener() {
				
				@Override
				public void mouseReleased(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}
				
				@Override
				public void mousePressed(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}
				
				@Override
				public void mouseExited(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}
				
				@Override
				public void mouseEntered(MouseEvent e) {
					// TODO Auto-generated method stub
					jb.setBackground(Color.GREEN);
				}
				
				@Override
				public void mouseClicked(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}
			});
		}
		
		frame.pack();
		frame.setVisible(true);
	}
}
