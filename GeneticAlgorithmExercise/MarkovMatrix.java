import java.util.Arrays;
import java.util.List;
import java.util.Set;
import java.util.HashSet;
import java.util.stream.*;

public class MarkovMatrix<T> implements Markov<T>{

 private T[] states;
 private int size;
 private double[][] Matrix;
 int[][] count;
 private int power;
 private int abr;

 public MarkovMatrix(T[] n){

  states = removeDuplicates(n);
  size = states.length;
  power = 1;
  abr = size;

  initMatrix(size);
 }

 private void initMatrix(int size){

  Matrix = new double[size][size];
  count = new int[size][size];

  for(int i = 0; i < size; ++i){
   for(int j =0; j < size; ++j){
    Matrix[i][j] = 0.0;
    count[i][j] = 0;
   }
  }
 }

 public int size(){
  return size;
 }

 public double dotProduct(int row, int col){
  double result = 0;
  for(int i = 0; i < size; ++i){
   result += Matrix[row][i]*Matrix[i][col];
  }
  return result;
 }

 public void pow(int n){
    double[][] newMatrix = new double[size][size];
    for(int e = 0; e < n; ++e){
     for(int i = 0; i < size; ++i){
      for(int j = 0; j < size; ++j){
       newMatrix[i][j] = dotProduct(i,j);
      }
     }
     power++;
    }
     for(int i = 0; i < size; ++i)
      for(int j = 0; j < size; ++j)
       Matrix[i][j] = newMatrix[i][j];
 }

 private T[] removeDuplicates(T[] states){
  Set<T> set = new HashSet<T>();
  for(T state: states)
   set.add(state);

  return (T[]) set.toArray();
 }

 private int indexOf(T s){
  return Arrays.asList(states).indexOf(s);
 }

 protected int rowSum(int i){
   return Arrays.stream(count[i]).sum();
 }

 private int maxCol(int row){
  double max = 0.0;
  int index = 0;
  for(int i = 0; i < size; ++i){
   if(Matrix[row][i] > max){
    max = Matrix[row][i];
    index = i;
   }
  }
  return index;
 }

 // Returns the state that is most likely to follow 's'
 public T nextState(T s){
  int i = maxCol ( indexOf(s) );
  return states[i];
 }

 // Find most frecuent state
 public T mostFrecuent(){
  int maxIndex = 0, maxCount = 0;
  for(int i = 0; i < size; ++i){
   int sum = rowSum(i);
   if( sum > maxCount ){
    maxCount = sum;
    maxIndex = i;
   }
  }
  return states[maxIndex];
 }

 //(!) data should be checked to see if there is no state that is not in "states"
 public void train(T[] data){
  for(int index = 0; index < data.length-1; ++index){
   int i = indexOf(data[index]);
   int j = indexOf(data[index+1]);
   count[i][j]++;
  }
  for(int i = 0; i < size; ++i){
   int total = rowSum(i);
   for(int j = 0; j < size; ++j){
    if(total > 0)
     Matrix[i][j] = ((double)count[i][j])/(double)total;
   }
  }
 }

 @Override
 public String toString(){
  String str = "  ";
  for(T s: states)
   str += s + "    ";

   str += "\n";

  for(int i = 0; i < size && i < abr; ++i){
   str += states[i] + " ";
   for(int j = 0; j < size && j < abr; ++j){
     str += String.format("%.2f", Matrix[i][j]) + " ";
   }
   str += "\n";
  }
  return str;
 }
}
