function y = fourier_transform(func, x1, x2, w)

y = integral(@(t)(func(t).*exp(-1i.*w.*t)), x1, x2);

end
