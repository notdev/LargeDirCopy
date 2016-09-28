# LargeDirCopy
Parallel move of many files in a directory (Files only, not recursive)

### Use case
Directory with millions of small files copying to CIFS share (Bottleneck can be both network and / or disk IO).   
Move operations start immediately as directory does not need to be enumerated.  
Parallel execution allows maximum usage of available system resources.
