function [outL1,outL2,outL3] = optFunction(inL1,inL2,inL3)
% inL1 = 1,inL2 = 2,inL3 = 3;
% %建立机器人模型
%        theta    d        a        alpha     offset
L1=Link([pi/2     0       0       -pi/2     0     ]); %定义连杆的D-H参数
L2=Link([-pi/2    inL1    0      pi/2        0     ]);
L3=Link([0        0       0       -pi/2     0     ]);
L4=Link([0        inL2   0         pi/2     0     ]);
L5=Link([0        0        0        -pi/2     0     ]);
L6=Link([0        inL3       0        0         0     ]);
robot=SerialLink([L1 L2 L3 L4 L5 L6],'name','ok'); %连接连杆，机器人取名ok
sumLen = inL1 + inL2 + inL3;

T = [trotx(pi/4),trotx(pi/2)];

for i = -sumLen:sumLen:sumLen
    for j = 0:sumLen:sumLen
        for k = -sumLen:sumLen:sumLen
            %if (i == 0 && j == 0 && k == 0)
            %    countiue;
            %end
            % posiMatrix = [1,0,0,i;0,1,0,j;0,0,1,k;0,0,0,1];
            posiMatrix = transl(i,j,k)
        end
    end
end

end


