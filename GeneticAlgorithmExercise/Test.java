import java.util.*;

public class Test extends Hangman implements Runnable{

 private String[] Words;
 private Player player;
 private boolean threaded = false;

 public Test(){
  this.player = new Player();
  this.Words = new String[1];
  this.Words[0] = "dummy";
 }
 public Test(Player player, String[] words){
  this.player = player;
  this.Words = words;
 }

 public void run(){
  testPlayer(player);
 }

 public void testPlayer(){
  run();
 }

 public void testPlayer(Player p){

     double fitness = 0.0;

     int completed = 0;
     for(int i = 0; i < Words.length; ++i){
       setWord(Words[i]);
      int tries = 0;
       while(p.hasNext() && alive()){
         tries++;
         Guess(p.next());
       }
       if(getScore() > 0) completed++;
       tries -= numLives - getScore();
       fitness += (((double)tries / (double)p.getNumGenes()));

       p.resetIterator();
     }

     fitness /= Words.length;
     fitness = fitness + (((double)completed) / (Words.length*0.4)) / 2;
     p.setFitness(fitness);
 }

 public void playInteractive(HangmanPlayer p, String word){

  setWord(word);
  int tries = 0;
  System.out.println("word: " + getWord());
  System.out.println(p);
  while(alive() && p.hasNext()){
     char c = p.next();
     Guess(c);
     tries++;
  }
  System.out.println("result: " + getWord());
  System.out.println("Score: " + getScore());
  System.out.println("right guesses: " + (tries - (numLives - getScore())));
  try{System.in.read();}catch(Exception e){}
 }

 public void nextGen(Player[] players, double crossoverFraction, double discardFraction){
  // mutations, crossovers and discarded
  // All mutate
  //for(Player p: players)
  // p.mutate();

  // Split the players into 3 parts:
  // The top players | The ones that will mutate | the ones that will be discarded
  int top = (int)Math.floor((double)players.length/3);
  int mutants = top;
  int discarded = top*2;
  for(int i = mutants; i < discarded; ++i){
   players[i].mutate();
  }
  for(int i = discarded; i < players.length; ++i)
   players[i] = new Player();
 }

 public void evolve(Player[] players,
                    int numGenerations,
                    double crossoverFraction,
                    double discardFraction){
  int numThreads = (int)Math.floor(players.length/10);
  Thread[] tests = new Thread[numThreads];
  threaded = true;
  for(int g = 0; g < numGenerations; ++g){
   if(g > 0) nextGen(players, crossoverFraction, discardFraction);
    if(threaded){

      for(int i =0; i < players.length;){

       int x = 0;
       for(; x < numThreads && (i+x) < players.length; ++x){
        tests[x] = new Thread(new Test(players[i+x], Words));
        tests[x].start();
       }
       for(int z = 0; z < x; ++z)
        try{
         tests[z].join();
        }catch(InterruptedException e){
         System.out.println(e);
        }
       //System.out.println("i: " + i + " x: " + x);
       //try{System.in.read();}catch(Exception e){}
       i+=x;
      }
    }else
     for(Player p: players){
      this.player = p;
      testPlayer();
     }

    System.out.println("===Generation " + (g+1) + " ===");
    Arrays.sort(players);
    Arrays.stream(players).forEach(System.out::println);
    //try{System.in.read();}catch(Exception e){}
  }//Generations
 }

 public static void main(String[] args){
  //----- TEST -----//
  Words w = new Words("wordlists/words.txt");
  String[] words = w.getWords();
  int numGenerations = 30;
  double crossoverFraction = 0.35;
  double discardFraction = 0.7;
  int numPlayers = 30;
  Player players[] = new Player[numPlayers];

  for(int i = 0; i < numPlayers; ++i)
   players[i] = new Player();

  Test myTest = new Test(new Player (), words);
  myTest.evolve(players,numGenerations,discardFraction,crossoverFraction);

  //for(int i =0; i < words.length; ++i){
  // myTest.playInteractive(players[numPlayers-1], words[i]);
  // players[numPlayers-1].resetIterator();
  //}

  // Markov Generated player test
   Character[] chars = //{'a', 'a', 'b', 'c', 'd'};
    "otorinolaringologia"
    .chars()
    .mapToObj(c -> (char)c)
    .toArray(Character[]::new);
  MarkovMatrix<Character> m = new MarkovMatrix<Character>(chars);
  m.train(chars);
  System.out.println(m.size());
  System.out.println(m);

   Character[] digits = //{'a', 'a', 'b', 'c', 'd'};
    "0123456789"
    .chars()
    .mapToObj(c -> (char)c)
    .toArray(Character[]::new);

  MarkovMatrix<Character> chain = new MarkovMatrix<Character>(digits);

  Character[][] number = {
   {'1', '2', '6', '7', '7', '8', '0', '1'},
   {'4', '8', '1', '5', '0', '2', '2', '3'},
   {'5', '8', '5', '5', '0', '1', '0', '3'},
   {'7', '6', '5', '4', '0', '3', '0', '0'},
  };

  System.out.println(chain);
  for(int i = 0; i < number.length; ++i){
   chain.train(number[i]);
   System.out.println(chain.size());
   System.out.println(chain);
   try{System.in.read();}catch(Exception e){}
  }
  for(int i = 0; i < 30; ++i){
   chain.pow(1);
   System.out.println("Powers...");
   System.out.println(chain.size());
   System.out.println(chain);
   try{System.in.read();}catch(Exception e){}
  }
  //MarkovPlayer marcos = new MarkovPlayer();
  //marcos.train(words);
  //System.out.println(marcos.size());
  //System.out.println(marcos);

  //for(int i =0; i < words.length; ++i){
  // myTest.playInteractive(marcos, words[i]);
  // marcos.resetIterator();
  //}
 }//static main
}
