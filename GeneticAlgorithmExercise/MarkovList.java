public class MarkovList<T> implements Markov<T>{

 public int size();

 public T nextState(T state);

 public T mostFrecuent();
}
