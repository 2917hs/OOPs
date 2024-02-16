
using System.Reflection.Metadata;
using InterviewQA;
using InterviewQA.ECommerceDiscount;
using static InterviewQA.ECommerceDiscount.Country;

Console.WriteLine("Hello, World!");

PrivateConstructor privateConstructor = new PrivateConstructor();
//private memebers are not accesible
//privateConstructor.age = 10;
privateConstructor.name = "Hasan";

BaseClass bc = new BaseClass();
bc.ChildClass1Method();

//will not be called because we made it new, so try creating object of ChildClass2
BaseClass cc1 = new ChildClass1();
cc1.ChildClass1Method();
ChildClass1 cc1New = new ChildClass1();
cc1New.ChildClass1Method();

BaseClass cc2 = new ChildClass2();
cc2.ChildClass1Method();

RefAndOut ro = new RefAndOut();
//value assignment before the call is mandatory for ref
int age = 5;
string name = "siddiqui";
ro.RefMethod(ref age, out name);
System.Console.WriteLine($"ref age {age} - {name}");
name = "siddiqui";
ro.OutMethod(out age, ref name);
System.Console.WriteLine($"out age {age} - {name}");

ConstReadonlyStatic crs = new ConstReadonlyStatic();
crs.SetVariables();

ObjectAndDynamic od = new ObjectAndDynamic();

BoxingUnboxing bu = new BoxingUnboxing();

ReturnTuple rt = new ReturnTuple();
System.Console.WriteLine(rt.Addition());

DelegatePrinter dp = new DelegatePrinter();

ConstructorTypes? ct = new ConstructorTypes();
ConstructorTypes ctcc = new ConstructorTypes(ct);
ct = null;
if (ctcc is null)
{
    System.Console.WriteLine("Copy constructor is ref. and null.");
}
else
{
    System.Console.WriteLine("Copy constructor is not ref. and not null.");
}

OpenClosed oc = new OpenClosed(new Child2());
if (oc is null)
{
    System.Console.WriteLine("oc is null");
}
else if (oc is { })
{
    System.Console.WriteLine("oc is not null");
}

"Extension Method".ConsoleWriteLine();

DelegateExample de = new DelegateExample();

DelegateExampleFuncActionPredicate defap = new DelegateExampleFuncActionPredicate();

Lambda l = new Lambda();

PrintBinaryNumkbers pbn = new PrintBinaryNumkbers(10);

CalculateOffersUsingDelegates c = new CalculateOffersUsingDelegates();

Console.WriteLine("Prototype Patter + Delegates => Satrt");
decimal price = 5000m;
decimal discountedPrice = 0;
FlatDiscountDelegate flatDiscountDelegate;
System.Console.WriteLine($"Actual price is : {price}");
Australia aus = new Australia();
Canada can = new Canada();
India ind = new India();
UnitedKingdom uk = new UnitedKingdom();
flatDiscountDelegate = aus.ApplyDiscount;
flatDiscountDelegate(price, ref discountedPrice);
Console.WriteLine($"Discounted price for Australia at 10% off : {discountedPrice}");
discountedPrice = 0m;
flatDiscountDelegate = can.ApplyDiscount;
flatDiscountDelegate(price, ref discountedPrice);
Console.WriteLine($"Discounted price for Canada at 20% off : {discountedPrice}");
discountedPrice = 0m;
flatDiscountDelegate = ind.ApplyDiscount;
flatDiscountDelegate(price, ref discountedPrice);
Console.WriteLine($"Discounted price for India at 30% off : {discountedPrice}");
discountedPrice = 0m;
flatDiscountDelegate = uk.ApplyDiscount;
flatDiscountDelegate(price, ref discountedPrice);
Console.WriteLine($"Discounted price for United Kingdom at 40% off : {discountedPrice}");
discountedPrice = 0;
flatDiscountDelegate = delegate (decimal price, ref decimal discountedPrice)
{
    discountedPrice = price * 0.05m;
    discountedPrice = price - discountedPrice;
};
flatDiscountDelegate(price, ref discountedPrice);
System.Console.WriteLine($"Discounted price for rest of the world at 5% off : {discountedPrice}");
Console.WriteLine("Prototype Patter + Delegates => End");

ParameterPassing pp = new ParameterPassing();

ThreadingExample te = new ThreadingExample();

IndicesAndRanges ir = new IndicesAndRanges();

UseCustomAttribute uca = new UseCustomAttribute();

DynamicProgramming dpp = new DynamicProgramming();

DelegatesChaining dc = new DelegatesChaining();

var gc = new GenericCollection<int>();
gc.Add(1);
gc.Add(2);
gc.PrintItem(item => System.Console.WriteLine(item));
Func<int, int> addby1 = (a) => { return a + 1; };
gc.PrintItemBy1(addby1);
gc.PrintItemUsingIEnumerable(new int[] { 1, 2, 3, 4, 5 })
    .ToList().ForEach(n => System.Console.WriteLine(n));



LINQPractice lp = new LINQPractice();

//PrimeNumbers pn = new PrimeNumbers();

AllSamples allSamples = new AllSamples();