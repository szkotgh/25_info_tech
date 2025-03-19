import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.awt.LayoutManager;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JSpinner;
import javax.swing.JTextField;

public class Main {
	public static JFrame main_frame = new JFrame();
	public static String[] test = {"1", "2", "3", "4", "5", "6", "7"};
	
	public static void main(String[] args) {
		main_frame.setTitle("test");
		main_frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		main_frame.setLocationRelativeTo(null);
		JComboBox jcb = new JComboBox(test);
		main_frame.add(new JComboBox());
		
		
		main_frame.setSize(100, 100);
		main_frame.setVisible(true);
	}
}
