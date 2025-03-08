package jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class db {
	
	public static Connection con;
	public static Statement stmt;
	

	public static void DBS() throws SQLException {
		con = DriverManager.getConnection("jdbc:mysql://localhost/?serverTimezone=UTC&allowLoadLocalInfile=true","root","1234");
		stmt = con.createStatement();
		
		stmt.execute("use Question");
	}
	
	public static ResultSet rs(String sql) throws SQLException{
		return stmt.executeQuery(sql);
	}
}
