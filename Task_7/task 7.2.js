var numbers =[];
var n_counter = 0;
var after_point = false;
var operands = [];
var o_counter = 0;
Calculator('1 + 4  - 3.1  * 2.8 /2=')

function Calculator(expression){
for (let i = 0; i < expression.length; i++){
    if (expression[i] != '+' &&
    expression[i] != '-' &&
    expression[i] != '*' &&
    expression[i] != '/' &&
    expression[i] != '=' &&
    expression[i] != ' '){
        ReadNumber(expression[i]);
    }else if (expression[i] != ' '){
        ReadOperand(expression[i]);
        after_point = false;
    }
}
    alert(numbers);
    alert(operands);

    var result = Calculate();
    alert(result);
}

function Calculate(){
    var result = numbers[0] - 0;

    for(let i = 1; i <= n_counter; i ++){
            if (i-1 < o_counter){
                switch (operands[i-1]){
                    case '+':
                        result += (numbers[i]-0);
                        break;
                    case '-':
                        result -= (numbers[i]-0);
                        break;
                    case '*':
                        result *= (numbers[i]-0);
                        break;
                    case '/':
                        result /= (numbers[i]-0);
                        break;
                        
                }
            }
    }

    return result;
}

function ReadNumber(char){
    if (char == '.'){
        n_counter--;
        numbers[n_counter] =numbers[n_counter] + '.';
        after_point = true;
    }else if (after_point){
        numbers[n_counter] =numbers[n_counter] + char;
        after_point = true;
        n_counter++;
    }
    else{
        numbers.push(char);
        n_counter++;
    }
}

function ReadOperand(char){
    if (char == '+'){
        operands.push('+');
        o_counter++;
    }else if(char == '-'){
        operands.push('-');
        o_counter++;
    }
    else if(char == '*'){
        operands.push('*');
        o_counter++;
    }
    else if(char == '/'){
        operands.push('/');
        o_counter++;
    }
}
