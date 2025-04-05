package jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class db {
	public static Connection con;
	public static Statement stmt;
	
	public static void init() {
		try {
			con = DriverManager.getConnection("jdbc:mysql://localhost/question?serverTimezone=UTC&allowLoadLocalInfile=true", "root", "1234");
			stmt = con.createStatement();		
			stmt.execute("use question");
		} catch (Exception e) {
			System.exit(1);
			e.printStackTrace();
		}
	}
	
	public static ResultSet execute(String sql) throws SQLException {
		return stmt.executeQuery(sql);
	}
}
