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
		} catch (Exception e) {
			e.printStackTrace();
			System.exit(1);
		}
	}
	
	public static ResultSet query(String sql_cmd) throws SQLException {
		return stmt.executeQuery(sql_cmd);
	}
}
