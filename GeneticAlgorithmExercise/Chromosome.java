import java.util.Random;

public class Chromosome implements Comparable<Chromosome>{

 private static final int defaultNumGenes = 32;
 protected int numGenes;
 protected double[] genes;
 protected double fitness;
 protected int mutation_fraction;
 protected int crossover_fraction;
 protected Random rand;

 public Chromosome(){
  this(defaultNumGenes,6,9);
 }

 public Chromosome(int n, int mutation_fraction, int crossover_fraction){
  numGenes = n;
  this.mutation_fraction = mutation_fraction;
  this.crossover_fraction = crossover_fraction;
  genes = new double[numGenes];
  rand = new Random();
  for(int i = 0; i < genes.length; ++i){
   genes[i] = rand.nextDouble();
  }
  // fitness = 0;
  // For testing
  fitness = rand.nextDouble();
 }

 public int getNumGenes(){
  return numGenes;
 }

 public double getGene(int i) throws IndexOutOfBoundsException {
  if(i < 0 || i >= numGenes) throw new IndexOutOfBoundsException();
  return genes[i];
 }

 public void setGene(int i, double value){
  genes[i] = value;
 }

 public double getFitness(){
  return this.fitness;
 }

 public void setFitness(double fitness){
  this.fitness = fitness;
 }

 public void mutate(){
  for(int i = 0; i<mutation_fraction; ++i){
   genes[rand.nextInt(numGenes)] = rand.nextDouble();
  }
 }

 public void crossover(Chromosome y){
  double tmp;
  int i = rand.nextInt(numGenes - crossover_fraction);
  int j = i + crossover_fraction;
  for(; i < numGenes && i < j; ++i){
   tmp = y.getGene(i);
   y.setGene(i, this.getGene(i));
   this.setGene(i, tmp);
  }
 }

 @Override
 public int compareTo(Chromosome o){
  //Comparison based on the fitness
  if( this.fitness > o.fitness ) return 1;
  else if( this.fitness < o.fitness ) return -1;
  else return 0;
 }
}
