package forms;

import java.awt.event.WindowEvent;

import aframe.aframe;

public class student_wrong_answer_note_form extends aframe {
	public student_wrong_answer_note_form() {
		fs("오답 노트");
		setSize(400, 400);
		sh();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		dispose();
		new student_main_form();
	}
}
