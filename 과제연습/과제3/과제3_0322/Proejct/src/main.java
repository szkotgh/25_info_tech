import forms.login_form;
import jdbc.db;

public class main {
	public static void main(String[] args) {
		try {
			db.init("question");
			new login_form();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
