package aframe;

import java.awt.BorderLayout;

import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class aframe extends JFrame {
	
	
	public String n = BorderLayout.NORTH;
	public String s = BorderLayout.SOUTH;
	public String w = BorderLayout.WEST;
	public String e = BorderLayout.EAST;
	public String c = BorderLayout.CENTER;
	
	public void fs(String title) {
		setTitle(title);
		
	}
	
	public void warning_msg(String msg) {
		JOptionPane.showMessageDialog(null, msg, "°æ°í",  0);
	}
}
