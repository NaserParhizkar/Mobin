//import 'reflect-metadata'

//class Person {
//    FirstName: string;
//    LastName: string;
//    BirthDate: Date;
//    //[key: string]: {} in keyof Person;
//}

////interface ObjectConstructor1 {
////    // ...
////    entries<T extends { [key: string]: any }, K extends keyof T>(o: T): [keyof T, T[K]][];
////    // ...
////}

////class MyClass implements ObjectConstructor1 {
////    entries<T extends { [key: string]: any; }, K extends keyof T>(o: T): [keyof T, T[K]][] {
////        debugger;
////        let result: Array<[keyof T, T[K]]>;
////        let arr: [keyof T, T[K]];

////        let a : K;

////        return result;
////    }
////}

////let c: MyClass = new MyClass();
////let p: Person = new Person();

////p.FirstName = "Naser";
////p.LastName = "Parhizkar";
////p.BirthDate = new Date("1989-11-11");
////debugger;

////let f = c.entries<Person, any>(p);

////f[0].forEach(t =>
////{
////    console.log(t);
////});



////function entries([key: string]> : any {

////}

////entries<


////let p: Person = new Person();
////p.FirstName = "1st name";
////p.LastName = "2nd name";

////let p2: Person = new Person();
////p2.FirstName = "Naser";
////p2.LastName = "Parhizkar";

////p[0] = p2;

////let v = p[0];

////debugger;

//let propeties = Reflect.getMetadata('design:properties', Person);

//debugger;
