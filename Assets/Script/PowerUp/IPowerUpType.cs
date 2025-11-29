//Interfaz comun para ejecutar asi los powersUps
public interface IPowerUpType {
    public void Apply(Paddle paddle);
    public void Reset()
    {
        //NOTHING TO DO
    }
}
