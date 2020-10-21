# flickinputprogramming_js
フリック入力プログラミング式_年齢測定

「パソコンなんていらない」
「フリック入力方が速いし」

はーーー？
じゃあ、フリック入力でプログラムしてみてくださいよ
でっきるよなぁ？

JavaScriptの問題です。時間計測機能付き

ちなみに俺にはフリック入力でプログラミングは無理でした

#解答例　FizzBuzz問題

```
function fizzBuzz(n){
   if( n % 3 == 0 && n % 5 == 0 ) return 'FizzBuzz';
   if( n % 3 == 0 ) return 'Fizz';
   if( n % 5 == 0 ) return 'Buzz';
   return n;
}
```

#解答例　フィボナッチ数

```
function fn(x){
   //まだ子供は生まれません
   if(x == 0 || x == 1) return 1;

   //一カ月前の数に増分を足します
   return fn(x - 1) + fn(x - 2);
}
```
