interface ICharacters 
{
    // Параметри
    public int CharactersID { get; }
    public string Name { get; }
    //public float MoveSpeed { get; set; }

    // Характеристики
    float Health { get; }
    float DMGATK { get; }
    float CritChancePercents { get; }
    float EnergyRecoveryPercents { get; }
    float EnergyForUltimates { get; }
    float NeedEnergyToUseUltimates { get; }

    // Методи
    void ChooseATK(); // обираємо вид атаки + вогора на якого вона буде застосована
    void MoveToEnemy(); // Персонаж іде до заданого ворога і завдає удару ????
    void MoveFromEnemyBack(); // Персонаж після атаки повертається назад
    void ATK1(); // 1 атака персонажа слаба атака урон повинен бути меньшим ??????
    void ATK2(); // 2 атака персонажа урон який показаний в характеристиках ??????
    void Ultimate(); // 3 атака урон повинен скейлитися в процентах + персонаж повинен накопичувати енергію щоб використати атаку
    void GetDMG(); // Метод який буде відповідати за обробку отриманого урону по персонажу
}