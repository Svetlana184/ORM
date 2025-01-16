// ПЕРЕГРУЗКА ОПЕРАЦИЙ
//не все операторы можно перегрузить
/*можно:
 * унарные операции - +х, -х, лог. НЕ, инверсия, ++, --, true, false
 * бинарные - +, -, *, /, %
 * операции сравнения - ==, !=, >, <, >=, <=
 * поразрядные операторы - И, ИЛИ, сдвиг влево, сдвиг вправо, искл. ИЛИ
 * логические операторы - &&, ||
 * 
 * 
 * операции, которые перегружаются парами:
 * ==, !=
 * >, <
 * <=, >=
 * 
 */

Counter counter1 = new Counter { Value = 45 };
Counter counter2 = new Counter { Value = 34 };
Counter sum = counter1.Add(counter2);
Console.WriteLine(sum.Value);
Counter sum2 = counter1 + counter2;
Console.WriteLine(sum2.Value);
Counter sub = counter1 - counter2;
Console.WriteLine(sub.Value);
bool res1 = counter1 > counter2;
Console.WriteLine(res1);
bool res2 = counter1 < counter2;
Console.WriteLine(res2);
Counter sum4 = counter1 + 56;
Console.WriteLine(sum4.Value);
Counter counter3 = counter1++;
Console.WriteLine(counter3.Value);
Console.WriteLine(counter1.Value);
if (!counter1) Console.WriteLine(true);
else Console.WriteLine(false);


//перегрузка операций. Преобразование типов
//explicit - явное преобразование
//implicit - неявное преобразование55

int x = (int)counter1;
Console.WriteLine(x);

Counter counter4 = 67;
Console.WriteLine(counter4.Value);



//перегрузка операций
class Counter
{
    public int Value { get; set; }

    public Counter Add(Counter c)
    {
        return new Counter { Value = this.Value + c.Value }; //this - ссылка на сам объект
    }

    public static Counter operator +(Counter c1, Counter c2)
    {
        return new Counter { Value = c1.Value + c2.Value };
    }
    public static Counter operator +(Counter c, int value)
    {
        return new Counter { Value = c.Value + value };
    }
    public static Counter operator -(Counter c1, Counter c2)
    {
        return new Counter { Value = c1.Value - c2.Value };
    }
    public static Counter operator *(Counter c1, Counter c2)
    {
        return new Counter { Value = c1.Value * c2.Value };
    }

    public static bool operator >(Counter c1, Counter c2)
    {
        return c1.Value > c2.Value;
    }
    public static bool operator <(Counter c1, Counter c2)
    {
        return c1.Value < c2.Value;
    }
    public static Counter operator ++(Counter c)
    {
        return new Counter { Value = c.Value++ };
    }
    public static Counter operator --(Counter c)
    {
        return new Counter { Value = c.Value-- };
    }
    public static bool operator true(Counter c)
    {
        return c.Value != 0;
    }
    public static bool operator false(Counter c)
    {
        return c.Value == 0;
    }
    public static bool operator !(Counter c)
    {
        return c.Value == 0;
    }



    public static implicit operator Counter(int x)
    {
        return new Counter { Value = x };
    }
    public static explicit operator int(Counter c)
    {
        return c.Value;
    }
}
