public interface Markov<T>{

 public int size();

 public T nextState(T state);

 public T mostFrecuent();
}
