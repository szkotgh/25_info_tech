package forms;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

import aframe.aframe;

public class b_join extends aframe {
	JTextField jt[] = new JTextField[4];
	GridBagConstraints grid;
	
	public void form() {
		card_form.p[1].setLayout(new BorderLayout());
		card_form.p[1].setBackground(Color.WHITE);
		card_form.p[1].add(cp=new JPanel(new GridBagLayout()), c);
		bk(cp, Color.WHITE);
		grid = new GridBagConstraints();
		grid.fill = GridBagConstraints.BOTH;
		grid.insets = new Insets(5, 2, 2, 2);
		GridXY(jl = new JLabel("아이디 : "), 0, 0, 1, 1);
		GridXY(jl = new JLabel("비밀번호 : "), 1, 0, 1, 1);
		GridXY(jl = new JLabel("이름 : "), 2, 0, 1, 1);
		GridXY(jl = new JLabel("생년월일 : "), 3, 0, 1, 1);
		GridXY(jt[0] = new JTextField(12), 0, 1, 1, 0);
		GridXY(jt[1] = new JTextField(), 1, 1, 1, 0);
		GridXY(jt[2] = new JTextField(), 2, 1, 1, 0);
		GridXY(jt[3] = new JTextField(), 3, 1, 2, 0);
		card_form.p[1].add(sp=new JPanel(new FlowLayout()), s);
		
		bk(sp, Color.WHITE);
		sp.add(jb = new JButton("가입"));
		sp.setBorder(new EmptyBorder(0, 0, 7, 0));
	}
	
	private void GridXY(Component c, int i, int j, int k, int l) {
		grid.gridx = j;
		grid.gridy = i;
		grid.gridwidth = l;
		grid.gridheight = k;
		cp.add(c, grid);
	}
}
