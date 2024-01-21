
public enum CharType 
{
    archer,
    melee,
    wizard
}

interface ICharacters 
{
    // ���������
    int CharactersID { get; }
    string Name { get; }
    bool IsDead { get; }
    CharType CharTypes { get; }
    //public float MoveSpeed { get; }

    // ��������������
    float Health { get; }
    float Speed { get; }
    float DMGATK { get; }
    int CritChance { get; }
    int EnergyRecovery { get; }
    float EnergyForUltimates { get; }
    float NeedEnergyToUseUltimates { get; }

    //// ������
    ////void ChooseATK(); // ������� ��� ����� + ������ �� ����� ���� ���� �����������
    //void MoveToEnemy(); // �������� ��� �� �������� ������ � ����� ����� ????
    //void MoveFromEnemyBack(); // �������� ���� ����� ����������� �����
    //void ATK1(); // 1 ����� ��������� ����� ����� ���� ������� ���� ������� ??????
    //void ATK2(); // 2 ����� ��������� ���� ���� ��������� � ��������������� ??????
    //void Ultimate(); // 3 ����� ���� ������� ���������� � ��������� + �������� ������� ������������ ������ ��� ����������� �����
    //void GetDMG(int Damage); // ����� ���� ���� ��������� �� ������� ���������� ����� �� ���������
    //void Dead();
}