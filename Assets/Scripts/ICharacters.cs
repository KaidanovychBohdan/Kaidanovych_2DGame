
public enum CharType 
{
    archer,
    melee,
    Wizard
}

interface ICharacters 
{
    // ���������
    int CharactersID { get; }
    string Name { get; }
    CharType CharTypes { get; }
    //public float MoveSpeed { get; }

    // ��������������
    float Health { get; }
    float DMGATK { get; }
    float CritChancePercents { get; }
    float EnergyRecoveryPercents { get; }
    float EnergyForUltimates { get; }
    float NeedEnergyToUseUltimates { get; }

    // ������
    void ChooseATK(); // ������� ��� ����� + ������ �� ����� ���� ���� �����������
    void MoveToEnemy(); // �������� ��� �� �������� ������ � ����� ����� ????
    void MoveFromEnemyBack(); // �������� ���� ����� ����������� �����
    void ATK1(); // 1 ����� ��������� ����� ����� ���� ������� ���� ������� ??????
    void ATK2(); // 2 ����� ��������� ���� ���� ��������� � ��������������� ??????
    void Ultimate(); // 3 ����� ���� ������� ���������� � ��������� + �������� ������� ������������ ������ ��� ����������� �����
    void GetDMG(); // ����� ���� ���� ��������� �� ������� ���������� ����� �� ���������
}