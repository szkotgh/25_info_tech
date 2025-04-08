package forms;

import java.awt.event.WindowEvent;

import aframe.aframe;

public class student_quiz_form extends aframe {
	public student_quiz_form() {
		fs("ДыБо");
		setSize(400, 400);
		sh();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		dispose();
		new student_main_form();
	}
}
