function [a0, B1, C1] = comp_fourier_koefs(func, n, x1, x2)

f=@(x)(func(x));
a0 = integral(f, x1, x2);
%B;
%C;



for i=1:n
    fcos=@(x)(func(x) .* cos(2*pi*i*x));
    fsin=@(x)(func(x) .* sin(2*pi*i*x));
    B1(i)=2 .* integral(fcos, x1, x2);
    C1(i)=2 .* integral(fsin, x1, x2);
end

%B1=B;
%C1=C;

xx=linspace(0, 1, 100);
yy(1)=0;
for j=1:100
    yy(j)=a0;
    for i=1:n
        yy(j) = yy(j) + B1(i)*cos(2*pi*i*xx(j))+C1(i)*sin(2*pi*i*xx(j));
    end
end

plot(xx, yy);
%plot(xx, func(xx));
end