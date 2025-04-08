package forms;

import java.awt.event.WindowEvent;

import aframe.aframe;

public class student_question_regi_form extends aframe {
	public student_question_regi_form() {
		fs("질문 등록");
		setSize(400, 400);
		sh();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		dispose();
		new student_main_form();
	}
}
