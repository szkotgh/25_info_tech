jb.addActionListener(e -> {
         try {
            for (int i = 0; i < jt.length; i++) {
               if (jt[i].getText().equals("")) {
                  msg.setText("빈칸이 있습니다.");
                  msg.setVisible(true);
                  return;
               }
            }
            
            if (jt[0].getText().equals("admin") && jt[1].getText().equals("1234")) {
               imsg("관리자님 환영합니다.");
               new l랭킹();
               dispose();
               return;
            }
            
            if (jt[0].getText().contains("tjstodsla")) {//포함하는 문자열
               rs = db.rs("select * from teacher where id ='" + jt[0].getText() + "'");
               ck = 1;
            } else {
               rs = db.rs("select * from user where id ='" + jt[0].getText() + "'");
               ck = 0;
            }
            
            if (rs.next()) {
               String pw = rs.getString(4);
               if (!pw.equals(jt[1].getText())) {
                  msg.setText("비밀번호가 일치하지 않습니다.");
                  msg.setVisible(true);
                  return;
               }
               
               vq.uno = rs.getInt(1);
               vq.uname = rs.getString(2);
               //vq.phone = rs.getString(5);
               //vq.birth = rs.getString(6);
               msg.setVisible(false);
               vq.role = ck;
               System.out.println(ck);
               if (ck == 0) {
                  vq.score = rs.getInt(8);
                  imsg(vq.uname + " 학생님 환영합니다.");
                  new e학생메인();
               } else {
                  imsg(vq.uname + " 선생님 환영합니다.");
                  new b선생님메인();
               }
               dispose();
               
            } else {
               msg.setText("존재하지 않는 회원입니다.");
               msg.setVisible(true);
               return;
            }
            
         } catch (Exception e2) {
            e2.printStackTrace();
         }
      });
      