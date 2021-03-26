public class Hangman{

 protected String Word;
 private int lives;
 protected final int numLives = 7;
 public int score;

 public Hangman(){
  Word = "";
  lives = numLives;
  score = 0;
 }

 public void setWord(String word){
  this.Word = word;
  lives = numLives;
  score = 0;
 }

 public String getWord(){
  return Word;
 }
 public void reset(){
  lives = numLives;
 }

 public boolean alive(){
  return lives > 0;
 }

 public int getScore(){
  return score;
 }

 public void Guess(Character guess){
  if(Word.contains(String.valueOf(guess))){
   Word = Word.replaceAll(String.valueOf(guess),"");
  }
  else{
   lives--;
  }
  if(Word.isEmpty()){
   score = lives;
   lives = 0;
  }
 }

}
