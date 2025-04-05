import java.sql.ResultSet;
import java.sql.SQLException;

import jdbc.db;

public class main {
	public static void main(String[] args) {
		try {
			ResultSet rs;
			
			rs = db.execute("SELECT * FROM user");
			
			while (rs.next()) {
				System.out.println(rs.getString(1) + " " + rs.getString(2));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
