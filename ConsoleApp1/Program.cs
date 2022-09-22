/*
    Surasti ilgiausia kelia duotoj matricoj is virsaus iki apacios
    Eiti galima tik zemyn, arba diagonaliai i desine per viena skaiciu.
    Skaiciai turi buti lyginis-nelyginis pvz. is 1 galima eiti tik i 8, is 8 galima eiti i 1 ir 5
 */

int[][] grafas = new int[][]
{
    new int[] { 1 },
    new int[] { 8, 9 },
    new int[] { 1, 5, 9 },
    new int[] { 4, 5, 2, 9 },
    new int[] { 3, 8, 13, 11, 5}
};

int[] kelias = new int[grafas.Length];
int[] maxKelias = new int[grafas.Length];
int maxSum = 0;

int maxSkaicius = 0;
string formatas = "";
Init();

void Init()
{
    FormuojamKontrole();
    for (int i = 0; i <= maxSkaicius; i++)
    {

        if (FormuojamKelia(i.ToString(formatas)))
        {
            int kelioIlgis = SkaiciuojamKelioIlgi();
            if (kelioIlgis > maxSum)
            {
                maxSum = kelioIlgis;
                for (int j = 0; j < kelias.Length; j++)
                {
                    maxKelias[j] = kelias[j];
                }
            }
        }
    }
    IsvestiDuomenis();
}
void IsvestiDuomenis()
{

    Console.WriteLine(maxSum);
    for (int i = 0; i < grafas.Length; i++)
    {
        Console.Write($"{grafas[i][maxKelias[i]]} ");
    }
}

void FormuojamKontrole()
{
    for (int i = 0; i < grafas.Length; i++)
    {
        maxSkaicius = maxSkaicius * 10 + i;
        formatas += "0";
    }
}

int SkaiciuojamKelioIlgi()
{
    int result = grafas[0][0];
    for (int i = 0; i < grafas.Length - 1; i++)
    {
        if (grafas[i][kelias[i]] % 2 != grafas[i + 1][kelias[i + 1]] % 2)
        {
            result += grafas[i + 1][kelias[i + 1]];
        }
        else
        {
            result = -1;
            break;
        }

    }
    return result;
}

bool FormuojamKelia(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        kelias[i] = int.Parse(data[i].ToString());
    }
    bool result = true;
    for (int i = 0; i < kelias.Length - 1; i++)
    {
        if (kelias[i + 1] - kelias[i] > 1 || kelias[i + 1] - kelias[i] < 0)
        {
            result = false;
            break;
        }
    }
    return result;
}
