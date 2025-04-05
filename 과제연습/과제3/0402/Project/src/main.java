import java.sql.ResultSet;
import java.sql.SQLException;

import jdbc.db;

public class main {
	public main() {
		ResultSet result;
		
		try {
			db.init();
			result = db.query("SELECT * FROM user");
			
			while (result.next()) {
				System.out.println(result.getString(1) + " " + result.getString(2));
			}			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
	}
}
