import java.util.List;
import java.util.ArrayList;
import java.io.FileReader;
import java.io.IOException;
import java.io.FileNotFoundException;
import java.io.BufferedReader;

public class Words implements wordParser{

 //private File f;
 private BufferedReader br;

 public Words(String fileName){
  try{
   this.br = new BufferedReader( new FileReader( fileName ));
   }catch(FileNotFoundException e){
     System.out.println(e);
   }
 }

 public String[] getWords(){
  List<String> words = new ArrayList();
  String line;
  try{
  while((line = br.readLine()) != null)
   if(line.length() > 1)
    words.add(line);
  }catch(IOException e){
   System.out.println(e);
  }
  return words.toArray(new String[words.size()]);
  }
}
