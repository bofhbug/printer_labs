T=1;
tau=0.8;
A=1; B=0;
Ng=50;

a0=2*(A*tau^2/2+B*tau)/T;
for i=1:Ng
    arg=2*pi*tau*i/T;
    a(i)=A*tau*sin(arg)/(pi*i)+A*T*cos(arg)/(2*(pi*i)^2)+B*sin(arg)/(pi*i)-A*T/(2*(pi*i)^2);
    b(i)=-A*tau*cos(arg)/(pi*i)+A*T*sin(arg)/(2*(pi*i)^2)-B*cos(arg)/(pi*i)+B/(pi*i);
end

time=0:0.01:2*T;
Nt=length(time);
ss=a0*ones(1,Nt)/2;

for i=1:Ng
    arg=2*pi*i*time/T;
    ss=ss + a(i)*cos(arg)+b(i)*sin(arg);
end

plot(time, ss);
grid on;

