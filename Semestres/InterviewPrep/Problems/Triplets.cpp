#include<bits/stdc++.h>

int main(){
    Triplets(6.0, 2);
    Triplets(7.0, 2);
    Triplets(8.0, 2);
    return 0;
}


vector<float> vec;

vector<float> Triplets(float v, float d){
    vec.push_back(v);
    
    float x, y, z;
    if(vec.size() >= 3){
        sort(vec.begin(), vec.end());
        int a=0,b=1,c=2;
        bool flag = true;
        while(c<vec.size()){
            if(abs(vec[a]-vec[b]) <= d) {
                if(abs(vec[a]-vec[c]) <= d){
                    if(abs(vec[b]-vec[c]) <= d){
                        //store the value
                        x = vec[a]; 
                        y = vec[b];
                        z = vec[c];

                        //delete them
                        vec.erase(a);
                        vec.erase(b);
                        vec.erase(c);
                        break;
                    }else{
                        flag = false;
                    }
                }
            }
            a++;
            b++;
            c++;
        } 
        if(flag == true) return {x,y,z};
        else return {};     
    }else{
        return {};
    }
}



