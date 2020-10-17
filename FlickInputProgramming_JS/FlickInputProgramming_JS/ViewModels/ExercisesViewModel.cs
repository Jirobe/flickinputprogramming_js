using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlickInputProgramming_JS.ViewModels
{
    public class ExercisesViewModel : BaseViewModel
    {
        public static ExercisesViewModel Current { get; private set; }

        private string answer = string.Empty;
        public string Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }

        private string question = string.Empty;
        public string Question
        {
            get { return question; }
            set { SetProperty(ref question, value); }
        }

        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        private string startText = string.Empty;
        public string StartText
        {
            get { return startText; }
            set { SetProperty(ref startText, value); }
        }

        private bool isVisibleStartButton = false;
        public bool IsVisibleStartButton
        {
            get { return isVisibleStartButton; }
            set { SetProperty(ref isVisibleStartButton, value); }
        }

        private string endText = string.Empty;
        public string EndText
        {
            get { return endText; }
            set { SetProperty(ref endText, value); }
        }

        private bool isVisibleEndButton = false;
        public bool IsVisibleEndButton
        {
            get { return isVisibleEndButton; }
            set { SetProperty(ref isVisibleEndButton, value); }
        }

        private bool isVisibleResult = false;
        public bool IsVisibleResult
        {
            get { return isVisibleResult; }
            set { SetProperty(ref isVisibleResult, value); }
        }

        private bool isVisibleAnswerEditor = false;
        public bool IsVisibleAnswerEditor
        {
            get { return isVisibleAnswerEditor; }
            set { SetProperty(ref isVisibleAnswerEditor, value); }
        }

        private HtmlWebViewSource result;
        public HtmlWebViewSource Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        private Stopwatch stopWatch;

        private CancellationTokenSource source;

        public ExercisesViewModel()
        {
            Current = this;

            Reset();
        }

        public void Reset()
        {
            IsVisibleResult = false;

            IsVisibleAnswerEditor = false;

            IsVisibleStartButton = true;
            IsVisibleEndButton = false;

            Text = string.Empty;

            StartText = "開始します";
            EndText = "解答！";

            Title = "FizzBuzz問題";

            Question =
                $@"
さあ、フリック入力でプログラミングをしよう！
JavaScriptでFizzBuzz関数を作ってくれ！
・引数は整数だ！
・戻り値は文字列だ！
・引数が3の倍数だと戻り値は「Fizz」だ！
・引数が5の倍数だと戻り値は「Buzz」だ！
・引数が3と5の倍数だと戻り値は「FizzBuzz」だ！
・上記に当てはまらないときは戻り値は引数をそのまま返す！
";
            Answer = $@"
            function fizzBuzz(n) 
            " + "{\r\n\r\nreturn;\r\n}";

            //            Answer =
            //"function fizzBuzz(n){\r\n" +
            //"   if( n % 3 == 0 && n % 5 == 0 ) return 'FizzBuzz';\r\n" +
            //"   if( n % 3 == 0 ) return 'Fizz';\r\n" +
            //"   if( n % 5 == 0 ) return 'Buzz';\r\n" +
            //"   return n;\r\n" +
            //"}";
        }

        public ICommand StartCommand => new Command(() =>
        {
            IsVisibleStartButton = false;
            IsVisibleEndButton = true;
            IsVisibleAnswerEditor = true;

            source = new CancellationTokenSource();
            TaskFactory factory = new TaskFactory(source.Token);

            stopWatch = new Stopwatch();
            stopWatch.Start();

            factory.StartNew(async () =>
            {
                while (true)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        TimeSpan ts = stopWatch.Elapsed;

                        Text = string.Format("{0:00}:{1:00}:{2:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    });

                    source.Token.ThrowIfCancellationRequested();

                    await Task.Delay(1000);
                }
            });

        });

        public ICommand EndCommand => new Command(() =>
        {

            IsVisibleResult = true;
            IsVisibleEndButton = false;
            IsVisibleAnswerEditor = false;

            source.Cancel();

            TimeSpan ts = stopWatch.Elapsed;
            string message = $@"結果({ts.TotalSeconds:#0.0}s)";
            switch (ts.TotalSeconds)
            {
                case double totalSeconds when totalSeconds <= 10: 
                    {
                        message += $@"UNKNOWN<br/>わからんのか？イレギュラーなんだよ。やりすぎたんだ。お前はな！";
                    }
                    break;
                case double totalSeconds when totalSeconds <= 30:
                    {
                        message += $@"10代<br/>キーボードより、ずっとはやい!!";
                    }
                    break;
                case double totalSeconds when totalSeconds <= 60:
                    {
                        message += $@"20代<br/>はやいな。これが時代か・・・";
                    }
                    break;
                case double totalSeconds when totalSeconds <= 300:
                    {
                        message += $@"30代～40代<br/>キーボードってすてきですよね";
                    }
                    break;
                case double totalSeconds when totalSeconds <= 600:
                    {
                        message += $@"50代<br/>キーボードってすてきですよね";
                    }
                    break;
                default: 
                    {
                        message += "60代以上<br/>キーボードってすてきですよね";
                    }
                    break;

            }


            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly myAssembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたマニフェストリソースを読み込む
            System.IO.StreamReader sr =
                new System.IO.StreamReader(
                myAssembly.GetManifestResourceStream("FlickInputProgramming_JS.Resources.ResultPage.html"),
                    System.Text.Encoding.GetEncoding("utf-8"));
            //内容を読み込む
            string s = sr.ReadToEnd();
            //後始末
            sr.Close();

            s = s.Replace("①",
$@"
result1.innerHTML = 'fizzBuzz(3) = ' + fizzBuzz(3);   
result2.innerHTML = 'fizzBuzz(25) = ' + fizzBuzz(25); 
result3.innerHTML = 'fizzBuzz(135) = ' + fizzBuzz(135); 
result4.innerHTML = 'fizzBuzz(98) = ' + fizzBuzz(98); 

result5.innerHTML = '答えが違うようです・・・。↑の引数でうまくいってないところがありますね'; 

if (fizzBuzz(3) == 'Fizz') if (fizzBuzz(25) == 'Buzz') if (fizzBuzz(135) == 'FizzBuzz') if (fizzBuzz(98) == '98')
result5.innerHTML = '{message}'; 
"
                );
            s = s.Replace("②", Answer);
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;

            //await scroll.ScrollToAsync(0, 0, true);
        });

    }
}