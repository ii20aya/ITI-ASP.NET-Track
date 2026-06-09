# Sample 3: The Optimization Challenge

This project is designed as an educational exercise where students audit a "bad" Dockerfile and compare it with a production-grade version.

## The Challenge
Audit `Dockerfile.bad` and identify 5-7 major issues. Then, examine the optimized `Dockerfile` to see how those issues were resolved.

### What to look for in `Dockerfile.bad`:
1.  **Base Image**: Is it using an SDK image for runtime? How big is the final image?
2.  **Layer Caching**: Is it copying the whole directory before `dotnet restore`?
3.  **Security**: Is the application running as `root`?
4.  **Size**: Is it using a heavy Debian/Ubuntu base instead of Alpine?
5.  **Reliability**: Does it have a `HEALTHCHECK`?
6.  **Instructions**: Are there unnecessary layers or inefficient commands?

## Instructions

### 1. Build the "Bad" Image
Observe the size and build time.
```powershell
docker build -t challenge-bad -f Dockerfile.bad .
```

### 2. Build the "Good" Image
Compare the size and efficiency.
```powershell
docker build -t challenge-good -f Dockerfile .
```

### 3. Compare Image Sizes
```powershell
docker images | findstr challenge
```
*You should see a difference of ~700MB!*

### 4. Check Security
Run the containers and check which user is running the process.
```powershell
docker run -d --name bad-app challenge-bad
docker exec bad-app whoami
# Output: root

docker run -d --name good-app challenge-good
docker exec good-app whoami
# Output: appuser
```

## Key Best Practices Demonstrated
- **Multi-stage Builds**: Separating the build environment from the runtime environment.
- **Alpine Linux**: Using minimal base images to reduce attack surface and download times.
- **Non-Root User**: Running as a limited user for defense-in-depth.
- **Docker Layer Caching**: Strategic use of `COPY` to avoid redundant restores.
- **Health Checks**: Making the container self-aware of its own status.
