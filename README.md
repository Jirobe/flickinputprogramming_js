# flickinputprogramming_js
フリック入力プログラミング式_年齢測定
  
https://play.google.com/store/apps/details?id=com.chibaniansoftworks.flickinputprogramming_js  
  
「パソコンなんていらない」  
「若者はフリック入力の方が速いし」  
  
と言われたという嘆きから生まれたアプリ  
  
ではフリック入力でプログラムをお願いします  
JavaScriptの問題です。時間計測機能付き  

# 解答例　FizzBuzz問題

```
function fizzBuzz(n){
   if( n % 3 == 0 && n % 5 == 0 ) return 'FizzBuzz';
   if( n % 3 == 0 ) return 'Fizz';
   if( n % 5 == 0 ) return 'Buzz';
   return n;
}
```

# 解答例　フィボナッチ数

```
function fn(x){
   //まだ子供は生まれません
   if(x == 0 || x == 1) return 1;

   //一カ月前の数に増分を足します
   return fn(x - 1) + fn(x - 2);
}
```
