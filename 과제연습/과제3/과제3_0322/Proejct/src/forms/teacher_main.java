package forms;

import java.awt.Font;
import java.awt.event.WindowEvent;

import javax.swing.JLabel;

import aframe.aframe;
import jdbc.vq;

public class teacher_main extends aframe {
	public teacher_main() {
		fs("선생메인");
		cp.add(jl = new JLabel(vq.uname + " 선생님 메인"));
		ft(jl, Font.BOLD, 32);
		shp();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		new login_form();
	}
}
