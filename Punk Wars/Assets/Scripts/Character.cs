class Character
{
    //Variables
    private int ID;
    private int HP;
    private int DEF;
    private int ATK;
    private int Speed;

    //Constructor
    private Character(int ID, int HP, int DEF, int ATK, int Speed)
    {
        this.ID = ID;
        this.HP = HP;
        this.DEF = DEF; 
        this.ATK = ATK; 
        this.Speed = Speed; 
    }

    //Getters and setters
    //Attribute 1
    public int GetID()
    {
        return ID;
    }

    public void SetID(int ID)
    {
        this.ID = ID;
    }


    //Attribute 2
    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int HP)
    {
        this.HP = HP;
    }


    //Attribute 3
    public int GetDEF()
    {
        return DEF;
    }

    public void SetDEF(int DEF)
    {
        this.DEF = DEF;
    }


    //Attribute 4
    public int GetATK()
    {
        return ATK;
    }

    public void SetATK(int ATK)
    {
        this.ATK = ATK;
    }


    //Attribute 5
    public int GetSpeed()
    {
        return Speed;
    }

    public void SetSpeed(int Speed)
    {
        this.Speed = Speed;
    }
}