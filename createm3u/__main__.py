"""
main.py
Main entry when executing createm3u as a 'program'

Use: python createm3u <base_path>
"""

import click

def print_help(ctx, opts, args):
    if args is False:
        return
    click.echo(ctx.get_help())
    ctx.exit()

@click.command()
@click.argument('basedir')
@click.pass_context
def main(basedir):
    pass

if __name__ == '__main__':
    main()