import java.util.Iterator;
import java.util.TreeMap;
import java.util.Collection;

public class Player extends Chromosome implements HangmanPlayer{

 private static final String alphabet = "abcdefghijklmnopqrstuvwxyz";
 private static final int numLetters = alphabet.length();
 private TreeMap<Double,Character> choices;
 private Iterator<Character> itr;

 public Player(){
  super(numLetters,8,10);
  sortLetters();
 }
 @Override
 public void mutate(){
  super.mutate();
  sortLetters();
 }

 public void crossover(Player y){
  super.crossover(y);
  y.sortLetters();
  sortLetters();
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

 public void sortLetters(){

  choices = new TreeMap<Double,Character>();
  for(int i =0; i < numLetters; ++i){
   choices.put((Double)genes[i],alphabet.charAt(i));
  }
  resetIterator();
 }

 @Override
 public String toString(){
  String str = "["+fitness+"](";
  while(itr.hasNext()){
   str += itr.next();
  }
  resetIterator();
  return str + ")";
 }

 public void printChart(){
  for(int j = 0; j < 10; ++j){
   System.out.print(" ");
   for(int i = 0; i < numLetters; ++i){
    if(genes[i] >= (double)(j)/10) System.out.print(" ");
    else System.out.print("#");

   }
   System.out.print(" \n");
  }
  System.out.println("("+alphabet+")");
 }
}
