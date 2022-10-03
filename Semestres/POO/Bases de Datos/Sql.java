import java.sql.*;
public class IIA{
  public static void main(String args[]){
    Connection c = null;
    Statement stmt = null;
    try{
      Class.forName("org.sqlite.JDBC");
      c = DriverManager.getConnection("jdbc:sqlite:iia.db");
      c.setAutoCommit(false);
      System.out.println("Base de datos disponible");
      stmt =c.createStatement(); 
      String sql = "INSERT INTO info(nombres,apellidos,hobby,sabor)" + "VALUES  ('Sara Carolina', 'Gómez Delgado', 'Tocar guitarra', 'Chocolate');";
      stmt.executeUpdate(sql);
      stmt.close();
      c.commit();
      c.close();
    }
    catch (Exception e){
      System.err.println(e.getClass().getName() + ": " + e.getMessage());
      return;
    }
  }
}
