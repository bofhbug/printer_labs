function lab4_1()
    Fs=6000;
    df=Fs/8;
    fmin=Fs/8;
    fmax=4*Fs;
    t=-0.006:0.0001:0.006;
    tn=-0.006:1/Fs:0.006;
    fv=fmin:fmax;
    for f=fmin:df:fmax
    x=cos(2*pi*f*t);
    plot(t,x,'k-'),hold on;
    xn=cos(2*pi*f*tn); % значения сигнала в точках временных отсчётов
    stem(tn,xn,'b-','filled');
    title(['Гармонический сигнал с частотой f= ' int2str(f) 'Hz']);
    hold off; 
    k=-0.006*Fs:1:0.006*Fs;
    tk=k/Fs;
    sk=cos(2*pi*f*tk);
    % Вычисление k-тых функций Котельникова
    for i=1:20
       angle=pi*Fs*t - k(i)*pi + .000000000001;
        K(i,:) = sin (angle) ./ angle;
    end
    s_rec=sk*K; % Восстановление импульса 
    hold on;
    plot(t, s_rec, 'r-'),hold off,pause;
    end;
    fk=[0, 200, 400, 599, 769, 588, 400, 200, 0];
    f1=[0, 200, 400, 600, 800, 1000, 1200, 1400, 1600];
    hold on;
    ylabel('fdiscr')
    xlabel('fsign')
    plot(f1, fk); hold off;
    %w = max(abs(fft(sk)))
end
