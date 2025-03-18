package jdbc;

import java.io.File;
import java.io.FileInputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JOptionPane;

public class db {
   
   public static void main(String[] args) throws Exception {
      try {
         DBS();
         JOptionPane.showMessageDialog(null, "성공", "성공", 1);
      } catch (Exception e) {
         e.printStackTrace();
         JOptionPane.showMessageDialog(null, "실패", "실패", 0);
      }
   }
   
    public static Connection con;
    public static Statement stmt;
    public static PreparedStatement pstmt;
   
   public static void DBS() throws SQLException {
      con = DriverManager.getConnection("jdbc:mysql://localhost/?serverTimezone=UTC&allowLoadLocalInfile=true", "root", "1234");
      stmt = con.createStatement();
      
      stmt.execute("drop database if exists clothingstore");
      stmt.execute("drop user if exists 'user'@'localhost'");
      stmt.execute("create database clothingstore");
      stmt.execute("create user 'user'@'localhost'");
      stmt.execute("grant select, insert, update, delete on clothingstore.* to 'user'@'localhost'");
      stmt.execute("use clothingstore");
      stmt.execute("set global local_infile=1;");
      
      stmt.execute("create table user(u_no int primary key not null auto_increment,u_id varchar(10),u_pw varchar(10),u_name varchar(10),u_price int, u_birth date, u_img longblob)");
      stmt.execute("create table category(c_no int primary key not null auto_increment, c_name varchar(10))");
      stmt.execute("create table subcategory(sb_no int primary key not null auto_increment, sb_name varchar(10), c_no int, foreign key(c_no) references category(c_no))");
      stmt.execute("create table productlist(p_no int primary key not null auto_increment, p_name varchar(50), p_price int, sb_no int, u_no int, p_s int, p_m int, p_l int, p_xl int, p_img longblob, foreign key(sb_no) references subcategory(sb_no),foreign key(u_no) references user(u_no))");
      stmt.execute("create table purchase(pu_no int primary key not null auto_increment, pu_date date, p_no int, u_no int, p_s int, p_m int, p_l int, p_xl int, foreign key(p_no) references productlist(p_no), foreign key(u_no) references user(u_no))");
      stmt.execute("create table salelist(sa_no int primary key not null auto_increment, start_date date, end_date date, sa_sale double, p_no int, foreign key(p_no) references productlist(p_no))");
      stmt.execute("create table shoppingbasket(s_no int primary key not null auto_increment,p_no int, u_no int, p_s int, p_m int, p_l int, p_xl int, foreign key(p_no) references productlist(p_no), foreign key(u_no) references user(u_no))");
      stmt.execute("create table Review(r_no int primary key not null auto_increment,pu_no int, r_content varchar(50), r_star varchar(10), foreign key(pu_no) references purchase(pu_no))");
      
      String[] table = "user,category,subcategory,productlist,purchase,salelist,shoppingbasket,Review".split(",");
      for (int i = 0; i < table.length; i++) {
         String data = "'datafiles/" + table[i] + ".txt'";
         stmt.execute("load data local infile " + data + " into table " + table[i] + " ignore 1 lines"); 
      }
      
      try {
         String a[] = "user,productlist".split(",");
         String b[] = "유저이미지,상품이미지".split(",");
         for (int i = 0; i < a.length; i++) {
            ResultSet rs = stmt.executeQuery("select * from " + a[i]);
            while (rs.next()) {
               pstmt = con.prepareStatement("update " + a[i] + " set " + a[i].substring(0, 1) + "_img = ? where " + a[i].substring(0, 1) + "_no = ?");
               FileInputStream fi = new FileInputStream(new File("datafiles/" + b[i] + "/" + rs.getString(1) + (i == 0 ? ".png" : ".jpg")));
               pstmt.setBinaryStream(1, fi);
               pstmt.setInt(2, rs.getInt(1));
               pstmt.execute();
            }
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
   }
}
