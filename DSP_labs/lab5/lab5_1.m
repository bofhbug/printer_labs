function lab5_1()
    Fs = 6000 / sqrt(8); %* 3 / 5;   % = 3600
    T = 1 / Fs;    %    2.78e-4
    N = 2^3;    % = 16   розрядність  
    n_steps = 10;   % кількість дискретних значень
    A = 1; % amplitude
    f_sin = @(t)(A*(sin(2*pi*Fs*0.35*t)));
    x = linspace(0, n_steps*T, n_steps);
    y_real = f_sin(x);
    %y_real(1)=0;
    %for i=1:10
    %    f_sin(
    %end
    %y_real
    quant_values = linspace(-A, A, N);

    x_cont = linspace(0, n_steps*T, 200);
    y_cont = f_sin(x_cont);
    plot (x_cont, y_cont);
    hold on;
    stem(x, y_real);

    y_quant_index(1)=0;
    for i=1:n_steps
        y_quant_index(i) = floor((y_real(i)+A)/(2*A)*(N-1)) + 1;
    end

    y_quant(1)=0;
    for i=1:n_steps
        y_quant(i) = quant_values(y_quant_index(i));
    end

    f_const = @(t)(1);
    for i=1:N
        %color red;
        y_const = quant_values(i)*f_const(x_cont);
        plot ( x_cont, y_const, 'r');
    end

    stem(x, y_quant, 'g');
    
    y_errors(1)=0;
    for i=1:n_steps
        y_errors(i) = y_quant(i) - y_real(i);
    end
    
    
    %hold off;
    %hist(y_errors, 200);
    
    variance = var(y_errors)
        
end