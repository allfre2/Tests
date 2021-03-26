import java.util.Iterator;
import java.util.TreeMap;
import java.util.Collections;

public class MarkovPlayer extends MarkovMatrix<Character> implements HangmanPlayer{

 private static final String alphabet = "abcdefghijklmnopqrstuvwxyz";
 private TreeMap<Double,Character> choices;
 private Iterator<Character> itr;

 public MarkovPlayer(){
    super(
    alphabet
    .chars()
    .mapToObj(c -> (char)c)
    .toArray(Character[]::new)
    );

    buildStrategy();
 }

 public void train(String[] strings){
  for(String s: strings){
   System.out.println("Trainning with: " + s);
   super.train(
   s.chars()
    .mapToObj(c -> (char)c)
    .toArray(Character[]::new)
   );
  }
  buildStrategy();
 }

 private void buildStrategy(){
  choices = new TreeMap<Double,Character>(Collections.reverseOrder());
  for(int i = 0; i < size(); ++i){
   choices.put(new Double(rowSum(i)),alphabet.charAt(i));
  }
  itr = choices.values().iterator();
 }

 public boolean hasNext(){
  return itr.hasNext();
 }

 public Character next(){
  return itr.next();
 }

 public void remove(){
  // pass
 }

 public void resetIterator(){
  itr = choices.values().iterator();
 }

 @Override
 public String toString(){
  String str = "(";
  while(itr.hasNext()){
   str += itr.next();
  }
  resetIterator();
  return str + ")";
 }
}
