import numpy as np

class ParticleSwarmOptimization:
    def __init__(self, nParticles, maxIter, func, bounds):
        assert isinstance(nParticles, int), 'nParticles is not int'
        assert isinstance(maxIter, int), 'maxIter is not int'
        # assert callable(func), 'func is not function'
        bounds = np.array(bounds)
        assert isinstance(bounds, np.ndarray), 'bounds is not np.ndarray'
        # args = np.array(args)
        # assert isinstance(args, np.ndarray), 'args is not np.ndarray'
        self.nParticles = nParticles
        self.maxIter = maxIter
        self.func = func
        self.bounds = bounds
        # self.args = args 
        self.w,self.c1,self.c2 = 0.9,0.9,0.9
    def _randomPositions(self):
        pass
    def _objectiveFunctionValues(self):
        pass
    def _getGBest(self):
        pass
    def _updateVelocity(self):
        pass
    def _updatePosition(self):
        pass

    def solve(self):
        r = self._solve()
        assert isinstance(r, dict), 'r is not dict'
        return r
    def _solve(self):
        self.w,self.c1,self.c2 = 0.9,0.9,0.9 # Initialize 𝑐1, 𝑐2, 𝑤
        # Create the particles positions and velocities randomly
        p = np.random.normal(size=(self.nParticles))
        v = np.random.normal(size=(self.nParticles))
        print(p,v)
        # Calculate the objective function values
        # Calculate 𝑃𝑏𝑒𝑠𝑡
        # 𝑖 as the current positions
        # Calculate 𝐺𝑏𝑒𝑠𝑡
        # While t < MaxIter or we haven’t found a good solution
            # For each particle 𝑖
                # Update the velocity:
                # 𝑣 𝑖(𝑡 + 1) = 𝑤 𝑣 𝑖 (𝑡) + 𝑐1 𝑟1 ( 𝑃𝑏𝑒𝑠𝑡
                # 𝑖 − 𝑥𝑖 (𝑡)) + 𝑐2 𝑟2 (𝐺𝑏𝑒𝑠𝑡 − 𝑥𝑖 (𝑡))
                # Update the position:
                # 𝑥𝑖 (𝑡 + 1) = 𝑥𝑖 (𝑡) + 𝑣 𝑖 (𝑡 + 1)
                # Calculate 𝑓𝑢𝑛𝑐(𝑥𝑖 )
                # If 𝑓(𝑥𝑖 ) < 𝑓𝑢𝑛𝑐(𝑃𝑏𝑒𝑠𝑡
                # 𝑖 ): update 𝑃𝑏𝑒𝑠𝑡
                # 𝑖
                # If 𝑓(𝑥𝑖 ) < 𝑓𝑢𝑛𝑐(𝐺𝑏𝑒𝑠𝑡): update 𝐺𝑏𝑒𝑠𝑡
        # Decrease 𝑐1, 𝑐2,𝑤
        return { }
def particle_swarm_optimization(nParticles, maxIter, func, bounds):
    PSO = ParticleSwarmOptimization(nParticles, maxIter, func, bounds)
    return PSO.solve()