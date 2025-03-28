import java.util.Properties;

public class main {
	public static void main(String[] args) throws Exception {
		for (String value : args) {
		    System.out.println(value);
		}
		System.out.println("----------------------------");
		
		Properties props = System.getProperties();
		System.out.printf("name=%s\n", props.get("name"));
		System.out.printf("age=%s\n", props.get("age"));
		System.out.printf("tel.home=%s\n", props.get("tel.home"));
		System.out.printf("tel.office=%s\n", props.get("tel.office"));
	}
}
