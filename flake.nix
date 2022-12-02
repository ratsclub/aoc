{
  description = "A very basic flake";

  inputs.nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";

  outputs = { self, nixpkgs }:
    let
      system = "x86_64-linux";
      pkgs = import nixpkgs { inherit system; };
    in
    {
      devShells."${system}".default = with pkgs; mkShell {
        buildInputs = [
          dotnet-sdk
          icu
        ];

        shellHook = ''
          export DOTNET_ROOT=${dotnet-sdk}
          export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:${lib.makeLibraryPath [ icu  ]}
        '';
      };
    };
}
