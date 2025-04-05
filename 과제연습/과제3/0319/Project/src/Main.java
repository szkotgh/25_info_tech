import java.sql.SQLException;

import forms.login_form;
import jdbc.db;

public class Main {
	public static void main(String[] args) throws SQLException {
		db.init();
		new login_form();
		
	}
}
